using System.ComponentModel.DataAnnotations;
using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace ECommerceWebUI.Models.ViewModels.AdminViewModels.ViewModel.Catalog
{
	public class CategoryViewModel
	{
		public int KategoriID { get; set; }
		public string KategoriAdi { get; set; }
		public string Tanimi { get; set; }
		public bool Aktif { get; set; }
		public string GorselUrl { get; set; }
		public IFormFile GorselFile { get; set; }
	}
}
