using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {

        List<Video> videos = new List<Video>();

        Video video1 = new Video("Product Review", "Tech Guru", 300);
        video1.AddComment(new Comment("Alice", "Great review! Very informative."));
        video1.AddComment(new Comment("Bob", "I learned a lot from this."));
        videos.Add(video1);

        Video video2 = new Video("Unboxing New Gadget", "Gadget Guy", 450);
        video2.AddComment(new Comment("Charlie", "Can't wait to get mine!"));
        video2.AddComment(new Comment("Diana", "Looks awesome!"));
        video2.AddComment(new Comment("Eve", "Thanks for the unboxing!"));
        videos.Add(video2);

        Video video3 = new Video("Top 10 Tech Tips", "Tech Savvy", 600);
        video3.AddComment(new Comment("Frank", "Tip number 5 is a game changer!"));
        videos.Add(video3);


        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");
            foreach (var comment in video.Comments)
            {
                Console.WriteLine($"- {comment.Name}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }
}

public class Video
{
    public string Title { get; private set; }
    public string Author { get; private set; }
    public int Length { get; private set; }
    public List<Comment> Comments { get; private set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return Comments.Count;
    }
}

public class Comment
{
    public string Name { get; private set; }
    public string Text { get; private set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}
