using Tweetinvi;

namespace MediaMonitoringWeb.Helpers
{
    public class TwitterHelper
    {
        TwitterClient client;
        public TwitterHelper(string CONSUMER_KEY, string CONSUMER_SECRET, string ACCESS_TOKEN, string ACCESS_TOKEN_SECRET)
        {
            client = new TwitterClient(CONSUMER_KEY, CONSUMER_SECRET, ACCESS_TOKEN, ACCESS_TOKEN_SECRET);

        }

        public async Task<List<string>> Search(string Keyword)
        {
            try
            {
                var tweets = await client.Search.SearchTweetsAsync(Keyword);
                return tweets.Select(x => x.FullText).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return default;
            }
           

        }

    }
}
