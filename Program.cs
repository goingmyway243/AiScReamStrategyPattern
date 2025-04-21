using System.Drawing;

internal interface ILyricStrategy
{
    string FavoriteThing { get; }
    Color FavoriteColor { get; }
}

internal sealed class RubyLyric : ILyricStrategy
{
    public string FavoriteThing => "Choko minto yori mo a･na･ta♡";
    public Color FavoriteColor => Color.FromArgb(255, 105, 180);
}

internal sealed class AyumuLyric : ILyricStrategy
{
    public string FavoriteThing => "Sutoroberii fureibaa yori mo a･na･ta♡";
    public Color FavoriteColor => Color.FromArgb(255, 111, 145);
}

internal sealed class ShikiLyric : ILyricStrategy
{
    public string FavoriteThing => "Kukkii & kuriimu yori mo a･na･ta♡";
    public Color FavoriteColor => Color.FromArgb(155, 143, 177);
}

internal sealed class EveryoneLyric : ILyricStrategy
{
    public string FavoriteThing => "Mochiron daisuki AiScReam";
    public Color FavoriteColor => Color.Yellow;
}

internal sealed class AiScReamMember
{
    private readonly ILyricStrategy _lyricStrategy;

    public AiScReamMember(ILyricStrategy lyricStrategy)
    {
        _lyricStrategy = lyricStrategy;
    }

    public void PerformLyric()
    {
        Colorful.Console.WriteLine(_lyricStrategy.FavoriteThing, _lyricStrategy.FavoriteColor);
    }

    public void SayHai()
    {
        Colorful.Console.WriteLine("Hai?", _lyricStrategy.FavoriteColor);
    }
}

public class Program
{
    public static async Task Main(string[] args)
    {
        var members = new (string Name, ILyricStrategy LyricStrategy)[]
        {
            ("Ruby-chan", new RubyLyric()),
            ("Ayumu-chan", new AyumuLyric()),
            ("Shiki-chan", new ShikiLyric()),
            ("Minna", new EveryoneLyric())
        };

        foreach (var (name, lyricStrategy) in members)
        {
            var member = new AiScReamMember(lyricStrategy);

            Console.WriteLine($"{name}!");
            await Task.Delay(1000);

            member.SayHai();
            await Task.Delay(1000);

            Console.WriteLine("Nani ga suki?");
            await Task.Delay(1500);

            member.PerformLyric();
            await Task.Delay(3800);
        }
    }
}
