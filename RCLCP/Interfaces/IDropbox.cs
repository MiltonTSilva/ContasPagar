namespace RCLCP.Interfaces
{
    public interface IDropbox
    {
        Task<string> GetDropboxFilePath(string accessToken, string dropboxFilePath, string localFilePath);
        Task<string> DownloadFileFromDropbox(string accessToken, string dropboxFilePath, string localFilePath);
        Task<string> UploadFileToDropbox(string accessToken, string dropboxFilePath, string localFilePath);

    }
}
