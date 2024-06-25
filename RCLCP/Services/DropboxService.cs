using Dropbox.Api;
using Dropbox.Api.Files;
using RCLCP.Interfaces;
using System.Net.Http.Headers;

namespace RCLCP.Services
{
    public class DropboxService : IDropbox
    {
        //https://csharp.hotexamples.com/examples/Dropbox.Api/DropboxClient/-/php-dropboxclient-class-examples.html

        //Consultar se token está ativo
        //https://api.dropboxapi.com/2/users/get_current_account
        // Bearer = token 

        private string retorno = string.Empty;

        public async Task<string>  GetDropboxFilePath(string accessToken, string dropboxPath, string localFilePath)
        {
            
            try
            {
                using (var dbx = new DropboxClient(accessToken))
                {
                    //var pathName = Path.GetDirectoryName(dropboxFilePath);
                    //pathName = pathName?.Replace("\\", "/");

                    var listFolderResult = await dbx.Files.ListFolderAsync(dropboxPath);

                    var files = listFolderResult.Entries;

                    var fileName = Path.GetFileName(localFilePath);
                    var fileMetadata = listFolderResult.Entries
                        .Where(i => i.IsFile && i.Name == fileName)
                        .FirstOrDefault();

                    retorno = fileMetadata!.PathLower;
                }

            }
            catch (Exception ex)
            {

                retorno = ex.HResult.ToString() + " - " + ex.Message;
            }

            return retorno;

        }

        public async Task<string> DownloadFileFromDropbox(string accessToken, string dropboxFilePath, string localFilePath)
        {
            try
            {
                using var httpClient = new HttpClient(new MyAndroidMessageHandler());

                using (var dbx = new DropboxClient(accessToken, new DropboxClientConfig { HttpClient = httpClient }))
                {
                    using (var response = await dbx.Files.DownloadAsync(dropboxFilePath))
                    {
                        var content = await response.GetContentAsStreamAsync();

                        using (var fileStream = File.Create(localFilePath))
                        {

                            await content.CopyToAsync(fileStream);
                        }
                    }
                }

                retorno = "Backup restaurado com sucesso!";
            }
            catch (Exception ex)
            {

                retorno = ex.HResult.ToString() + " - " + ex.Message;
            }

            return retorno;
        }

        public async Task<string> UploadFileToDropbox(string accessToken, string dropboxFilePath, string localFilePath)
        {
            try
            {
                using (var dbx = new DropboxClient(accessToken))
                {

                    using (var fileStream = File.OpenRead(localFilePath))
                    {
                        var updated = await dbx.Files.UploadAsync(
                            dropboxFilePath,
                            WriteMode.Overwrite.Instance,
                            body: fileStream).ConfigureAwait(false); ;

                    }
                }

                retorno = "Backup concluido com sucesso!";
            }
            catch (Exception ex)
            {

                retorno = ex.HResult.ToString() + " - " + ex.Message;
            }

            return retorno;

        }

        public class MyAndroidMessageHandler : HttpClientHandler
        {
            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                if (request.RequestUri!.AbsolutePath.Contains("files/download"))
                {
                    request.Content!.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                }
                return await base.SendAsync(request, cancellationToken);
            }
        }
    }
}