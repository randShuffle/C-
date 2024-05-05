// using System;
// using System.Net;
// using System.Threading.Tasks;

// namespace TasKCompletionSource
// {
//     public class AsyncWebClient
//     {
//         public static Task<byte[]> GetDataAsync(string uri)
//         {
//             // create completion source
//             var tcs = new TaskCompletionSource<byte[]>();
//             // create a web client for downloading the string
//             var wc = new WebClient();
//             // Subscribe to the completed event
//             wc.DownloadDataCompleted += (s, e) =>
//             {
//                 if (e.Error != null)
//                 {
//                     // If the download failed, set the error on the taskcompletion source
//                     tcs.TrySetException(e.Error);
//                 }
//                 else if (e.Cancelled)
//                 {
//                     // If the download was cancelled, signal cancellation to the task completion source
//                     tcs.TrySetCanceled();
//                 }
//                 else
//                 {
//                     // If the download was successful, set the result on the task completion source
//                     tcs.TrySetResult(e.Result);
//                 }
//                 wc.Dispose();
//             };
//             // Start the asynchronous download
//             wc.DownloadDataAsync(new Uri(uri));
//             // Returns after the value has been added by trySetResult
//             return tcs.Task;
//         }
//     }
//     class Program
//     {
//         static async Task Main(string[] args)
//         {
//             await AsyncWebClient.GetDataAsync("https://www.sina.com.cn");
//             Console.WriteLine("Operation is completed");
//         }
//     }
// }
