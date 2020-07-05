namespace TelegramBotAdminPanel
{
    struct MessageLog
    {
        public string Time { get; set; }

        public long Id { get; set; }

        public string Msg { get; set; }

        public string FirstName { get; set; }

        public MessageLog(string Time, string Msg, string FirstName, long Id)
        {
            this.Time = Time;
            this.Msg = Msg;
            this.FirstName = FirstName;
            this.Id = Id;
        }

        //public override string ToString()
        //{
        //    return $"{Time} {Msg} {FirstName}";
        //}
    }
}
