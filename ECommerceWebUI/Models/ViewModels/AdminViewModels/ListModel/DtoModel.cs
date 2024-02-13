using System.Collections.Generic;

namespace ECommerceWebUI.Models.ViewModels.AdminViewModels.ListModel
{
	public class DtoModels
	{
		public List<DataModel> Data { get; set; }

	}
	public class DataModel
	{
		public int postId { get; set; }
		public int id { get; set; }
		public string name { get; set; }
		public string email { get; set; }
		public string body { get; set; }
	}
}
