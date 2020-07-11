namespace PlayersInfo.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public ApiResponse(int statusCode, string message = null)
        {
            this.Message = message  ?? GetDefaultMessageForStatusCode(statusCode);
            this.StatusCode = statusCode;
        }
        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "You have made a bad request, you have made",
                401 => "you are not Authorized ",
                404 => "Resource was not found",
                500 => "Errors are the path to the dark side. Errors lead to anger.  Anger leads to hate.  Hate leads to career change",
                _ => null
            };
        }
    }
}