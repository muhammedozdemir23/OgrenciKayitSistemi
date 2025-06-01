using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciKayitSistemi.Application.DTOs.Models.Ortak
{
	public class ServiceResponse<T>
	{
		public bool IsSuccess { get; private set; }
		public string Message { get; private set; }
		public T Data { get; private set; }

		public ServiceResponse(bool isSuccess, string message, T data)
		{
			IsSuccess = isSuccess;
			Message = message;
			Data = data;
		}
	}
}
