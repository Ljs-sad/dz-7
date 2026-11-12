namespace MetodichkaTumakov
{
    public class Song
    {
        string name;
        string author;
        Song prev;

        public Song()
        {
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public void SetAuthor(string author)
        {
            this.author = author;
        }

        public void SetPrev(Song prevSong)
        {
            prev = prevSong;
        }
        public Song GetPrev()
        {
            return prev;
        }

        public string Title()
        {
            return $"{name} - {author}";
        }

        public override bool Equals(object d)
        {
            Song prevName = d as Song;
            if (prevName == null)
            {
                return false;
            }
            return name == prevName.name && author == prevName.author;
        }
    }
}
