﻿namespace MyStore.Web.Models.DTO
{
    public class Response
    {
        public string Message { get; set; } = "";
        public bool IsSuccess { get; set; } = true;
        public object? Result { get; set; }



    }
}
