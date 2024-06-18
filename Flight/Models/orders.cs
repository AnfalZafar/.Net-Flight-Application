namespace Flight.Models
{
	public class orders
	{
		public int o_id {  get; set; }
		public string users_name { get; set; }
		public string users_email { get; set; }
		public string users_id { get; set; }
		public string flight_sets { get; set; }
		public string flight_name { get; set; }
		public string flight_to { get; set; }
		public string flight_from { get; set; }
		public string total_price { get; set; }
		public string amount_of_flights { get; set; }
	}
}
