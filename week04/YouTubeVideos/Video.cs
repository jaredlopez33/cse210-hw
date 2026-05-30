using System.Collections.Generic;
public class Video
{
    private string _title;
    private string _author;
    private int _lengthInSeconds;
    private List<Comment> _comments;

    public Video(string title, string author, int lengthInSeconds)
    {
        _title = title;
        _author = author;
        _lengthInSeconds = lengthInSeconds;
        _comments = new List<Comment>();
    }
    public string Title
    {
        get { return _title; }
        set { _title = value; }
    }

    public string Author
    {
        get { return _author; }
        set { _author = value; }
    }

    public int LengthInSeconds
    {
        get { return _lengthInSeconds; }
        set { _lengthInSeconds = value; }
    }

    public List<Comment> Comments
    {
        get { return _comments; }
    }
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }
    public int GetNumberOfComments()
    {
        return _comments.Count;
    }
}