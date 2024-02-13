using Api.TestApiHelper.TestApiDto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Api.Concrete
{
	public class TestServerApi
	{
		public async Task<Dto> TestApiResponse(string url)
		{
			HttpClient client= new HttpClient();
			Dto dto=new Dto();

			dto=JsonConvert.DeserializeObject<Dto>(await client.GetStringAsync(url));
			
			return dto;
		}
	}
}
