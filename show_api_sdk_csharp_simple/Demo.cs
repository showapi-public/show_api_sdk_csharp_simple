using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Net;
namespace showapi
{
	class Demo
	{
		
		//使用get的示例
		public static void get_demo(){
				Console.WriteLine("get_demo  begin...");
				String  url="https://route.showapi.com/294-1";
				Dictionary<  string, string> param=new  Dictionary<string,string>() ;
				param.Add("showapi_appid","替换此值");
				param.Add("showapi_sign","替换此值")	;
				param.Add("t1","易源数据，万维一源");	
				param.Add("t2","易源数据，万数同源");	
					
	//		    添加Post 参数  
			    StringBuilder builder = new StringBuilder();  
			    foreach (var item in param)  
			    {  
			    	builder.AppendFormat("{0}={1}&", item.Key, myUrlEncode(item.Value ));
			    }  
			  
			    Console.WriteLine(builder.ToString());
			    byte[] data = Encoding.UTF8.GetBytes(builder.ToString());
			    url=url+"?"+builder.ToString();
			    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);  
			    req.Method = "GET";  
			    req.ContentType = "application/x-www-form-urlencoded";  
			    HttpWebResponse resp = (HttpWebResponse)req.GetResponse();  
			    Stream stream = resp.GetResponseStream();  
			    //获取响应内容  
			    String result = "";  
			    using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))  
			    {  
			        result = reader.ReadToEnd();  
			    }  
			    Console.Write("\r\nbelow is return content:");
				Console.WriteLine(result);
				
				//以下根据result进行json解析，并做业务处理
				Console.Write("\r\ndo some businese");
				Console.ReadKey(true);
		}
		
		
		//使用post的示例
		public static void post_demo(){
				Console.WriteLine("post_demo begin...");
				String  url="https://route.showapi.com/28-1";
				Dictionary<  string, string> param=new  Dictionary<string,string>() ;
				param.Add("showapi_appid","替换此值");
				param.Add("showapi_sign","替换此值")	;
				param.Add("t1","易源数据，万维一源");	
				param.Add("t2","易源数据，万数同源");	
					
			    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);  
			    req.Method = "POST";  
			    req.ContentType = "application/x-www-form-urlencoded";  
	//		    添加Post 参数  
			    StringBuilder builder = new StringBuilder();  
			    foreach (var item in param)  
			    {  
			        builder.AppendFormat("{0}={1}&", item.Key, myUrlEncode( item.Value));
			    }  
			    Console.WriteLine(builder);
			    byte[] data = Encoding.UTF8.GetBytes(builder.ToString());  
			    req.ContentLength = data.Length;  
			    using (Stream reqStream = req.GetRequestStream())  
			    {  
			        reqStream.Write(data, 0, data.Length);  
			        reqStream.Close();  
			    }  
			    HttpWebResponse resp = (HttpWebResponse)req.GetResponse();  
			    Stream stream = resp.GetResponseStream();  
			    //获取响应内容  
			    String result = "";  
			    using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))  
			    {  
			        result = reader.ReadToEnd();  
			    }  
			    Console.Write("\r\nbelow is return content:");
				Console.WriteLine(result);
				
				//以下根据result进行json解析，并做业务处理
				Console.Write("\r\ndo some businese");
				Console.ReadKey(true);
		}
		
		
		//使用base64的示例
		public static void base64_demo(){
				Console.WriteLine("post_demo begin...");
				String  url="https://route.showapi.com/184-5";
				Dictionary<  string, string> param=new  Dictionary<string,string>() ;
				param.Add("showapi_appid","替换此值");
				param.Add("showapi_sign","替换此值")	;
				param.Add("img_base64",file_to_base64("c:/verify.jpg"))	;
				param.Add("typeId","34")	;
				

			    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);  
			    req.Method = "POST";  
			    req.ContentType = "application/x-www-form-urlencoded";  
	//		    添加Post 参数  
			    StringBuilder builder = new StringBuilder();  
			    foreach (var item in param)  
			    {  
			    	builder.AppendFormat("{0}={1}&", item.Key, myUrlEncode( item.Value));
			    }  
			    Console.WriteLine(builder);
			    byte[] data = Encoding.UTF8.GetBytes(builder.ToString());  
			    req.ContentLength = data.Length;  
			    using (Stream reqStream = req.GetRequestStream())  
			    {  
			        reqStream.Write(data, 0, data.Length);  
			        reqStream.Close();  
			    }  
			    HttpWebResponse resp = (HttpWebResponse)req.GetResponse();  
			    Stream stream = resp.GetResponseStream();  
			    //获取响应内容  
			    String result = "";  
			    using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))  
			    {  
			        result = reader.ReadToEnd();  
			    }  
			    Console.Write("\r\nbelow is return content:");
				Console.WriteLine(result);
				
				//以下根据result进行json解析，并做业务处理
				Console.Write("\r\ndo some businese");
				Console.ReadKey(true);
		}
		
		
		
		//使用文件上传的示例
		public static void file_demo(){
				string postURL = "http://route.showapi.com/184-4";
				Dictionary<string, object> postParameters = new Dictionary<string, object>();
				postParameters.Add("showapi_appid","替换此值");
				postParameters.Add("showapi_sign","替换此值")	;
				postParameters.Add("typeId", "34");
				postParameters.Add("image", getUploadFilePara("c:/verify.jpg"));
				
				// Create request and receive response
				HttpWebResponse webResponse = FormUpload.MultipartFormDataPost(postURL,  postParameters);
				
				// Process response
				StreamReader responseReader = new StreamReader(webResponse.GetResponseStream());
				string fullResponse = responseReader.ReadToEnd();
				webResponse.Close();
				
				Console.Write(fullResponse);
				Console.Write("\r\ndo some businese");
				Console.ReadKey(true);
		}
		
		
		//自定义的方法，构造上传的文件对象
		private static FormUpload.FileParameter  getUploadFilePara(string filePath)
        {
           		FileStream fs = new FileStream(@filePath,FileMode.Open);//初始化文件流
	            byte[] array = new byte[fs.Length];//初始化字节数组
				fs.Read(array, 0, array.Length);//读取流中数据到字节数组中
				fs.Close();//关闭流
				String fileName=fs.Name;
	
				FormUpload.FileParameter image = new FormUpload.FileParameter(array,fileName);
				return  image;
        }
		
		//自定义的urlencode方法，这样就用引用web包的内容
		private static string myUrlEncode(string str)
        {
            StringBuilder sb = new StringBuilder();
            byte[] byStr = System.Text.Encoding.UTF8.GetBytes(str); //默认是System.Text.Encoding.Default.GetBytes(str)
            for (int i = 0; i < byStr.Length; i++)
            {
                sb.Append(@"%" + Convert.ToString(byStr[i], 16));
            }
            
            return (sb.ToString());
        }
		
		//自定义的方法，把文件读取后转为base64
		private static string file_to_base64(string filepath)
        {
            FileStream fs = new FileStream(@filepath,FileMode.Open);//初始化文件流
            byte[] array = new byte[fs.Length];//初始化字节数组
			fs.Read(array, 0, array.Length);//读取流中数据到字节数组中
			fs.Close();//关闭流
			string base64string=Convert.ToBase64String(array);
			Console.Write("\r\n"+base64string);
            return (base64string);
        }
	
		
		public static void Main(string[] args)
		{
			//以下是4个测试方法
			
//			Demo.get_demo();
			Demo.post_demo();
//			Demo.base64_demo();
//			Demo.file_demo();
			
			
			
			
			
			
			
		}
	}
}