using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Net.Http.Headers;


namespace RobotCleaner
{
    
    public static class Networking
    {
        
        const string EndPoint_URL = "http://lorensbergshost.azurewebsites.net/Robot/GetStartPresets";

        const string subscriptionKey = "8c2c9d32e33b4e9589023f572f5d8a19";

		const string uriBase = "https://southeastasia.api.cognitive.microsoft.com/vision/v1.0/ocr";

        const string accessKey = "462180a0f939442aaeb638da1194b47a";

        public static async Task<string> PostRequest(object obj)
        {
			try
			{
				HttpClient Client = new HttpClient();
				
                var data = JsonConvert.SerializeObject(obj);
				
                var content = new StringContent(data, Encoding.UTF8, "application/json");
				
                var response = await Client.PostAsync(EndPoint_URL, content);

                response.EnsureSuccessStatusCode();

				string Rcontent = await response.Content.ReadAsStringAsync();

                Client.Dispose();

				return Rcontent;

			}
			catch (Exception ex)
			{	
                Debug.WriteLine(ex.Message);
				return "Error";
			}
        }

        public static async Task<string> MakeOCRRequest(byte[] image)
		{
            try
            {                
                HttpClient client = new HttpClient();

                // Request headers.
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

                // Request parameters.
                string requestParameters = "language=unk&detectOrientation=true";

                // Assemble the URI for the REST API Call.
                string uri = uriBase + "?" + requestParameters;

                //var content = new MultipartFormDataContent();

                //            var fileContent = new ByteArrayContent(imageFile);

                //fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                ////fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                ////{
                ////	FileName = "image.jpg",
                ////	Name = "file"
                ////};

                //content.Add(fileContent);

                //HttpResponseMessage response = await client.PostAsync(
                //    uri,
                //    content
                //);


                //if (response.IsSuccessStatusCode)
                //{
                //    string con = await response.Content.ReadAsStringAsync();
                //    return con;
                //}
                //else 
                //return null;


                HttpResponseMessage response;

                // Request body. Posts a locally stored JPEG image.            

                using (ByteArrayContent content = new ByteArrayContent(image))
                {
                    // This example uses content type "application/octet-stream".
                    // The other content types you can use are "application/json" and "multipart/form-data".
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                    // Execute the REST API call.
                    response = await client.PostAsync(uri, content);

                    // Get the JSON response.
                    string contentString = await response.Content.ReadAsStringAsync();

                    // Display the JSON response.
                    return contentString;
                    //Console.WriteLine(JsonPrettyPrint(contentString));

                }

            }
			catch (HttpRequestException e)
			{
				Console.WriteLine(e.InnerException.Message);
                return null;
			}


		}

		static byte[] GetImageAsByteArray(string imageFilePath)
		{
			FileStream fileStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read);
			BinaryReader binaryReader = new BinaryReader(fileStream);
            var b = binaryReader.ReadBytes((int)fileStream.Length);
            return b;
		}


	}
}
