namespace TradeTracker.Application.Models.Navigation
{
    public class LinkDto
    {
        public string _href { get; private set; }
        public string _rel { get; private set; }
        public string _method { get; private set; }

        public LinkDto(string href, string rel, string method)
        {
            _href = href;
            _rel = rel;
            _method = method;
        }
    }
}
