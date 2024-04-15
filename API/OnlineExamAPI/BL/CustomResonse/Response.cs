namespace OnlineExamAPI.BL
{
    public class Response<T>
    {
        public int statusCode { get; set; }
        public  object message { get; set; }
        public T? result { get; set; }  
        //public IEnumerable<T> results { get; set; }
        //public string Data { get; set; }


    }
}
