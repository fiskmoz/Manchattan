namespace Client.Model
{
	class Contact
	{
		public string name { get; private set; }
		public bool isOnline;
        public string status { get; set; }

        public Contact(string name, bool isOnline)
		{
			this.name = name;
			this.isOnline = isOnline;
            this.status = "Status";
		}
	}
}
