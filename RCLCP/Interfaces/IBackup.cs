namespace RCLCP.Interfaces
{
    public interface IBackup
    {
        bool MakeBackup();
        bool ReadFile();
        bool WriteFile();
    }
}
