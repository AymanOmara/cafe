﻿using System.Text.Json;

namespace cafe.Application.Utils
{
	public class BaseResponse<T>
	{
		public string? message { get; set; }
		public T? data { get; set; }
        public bool success { get; set; }
        public int? statusCode { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}

