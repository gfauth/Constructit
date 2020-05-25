namespace Dados.Models
{
    public class ViewStatus
    {
        public string message { get; set; }
        public int status { get; set; }

        public ViewStatus(string _message, int _status)
        {
            message = _message;
            status = _status;
        }
        public ViewStatus(int _status)
        {
            message = string.Empty;
            status = _status;
        }

        public ViewStatus()
        {
            message = string.Empty;
            status = 0;
        }

    }
}
