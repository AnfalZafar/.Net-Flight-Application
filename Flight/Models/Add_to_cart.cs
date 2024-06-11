namespace Flight.Models
{
	public class Add_to_cart
	{
		public string from { get; set; }
		public string to { get; set; }
		public string flight_name { get; set; }
		public string price { get; set; }
		public string qty { get; set; }
		public string user_id { get; set; }
		public string user_name { get; set; }
		public string user_email { get; set; }
		public string s_id { get; set; }

	}
	public static class add_list
	{
		public static List<Add_to_cart> List = new List<Add_to_cart>();
	}
}
