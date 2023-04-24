﻿namespace crud.core.Helpers
{
    public class BaseResult<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public string Message { get; set; }
    }
}