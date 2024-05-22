public class Define
{
    public enum AreaType
    {
        Sphere,
        Cube
    }

    public enum CameraDirection
    {
        NE,
        SE,
        SW,
        NW
    }

    public enum FadeType
    {
        Black,
        White
    }

    public enum FD_Phase
    {
        Start,
        Childhood,
        Adolescence,
        Earlyadulthood,
        End
    }

    public enum Scene
    {
        MN,
        FD, 
        FM, 
        ST,
        LV, 
        MR,
        NONE
    }
}

namespace Game.LV
{
    public enum Phase
    {
        OneOrder,
        AddOrder,
        TooMuchOrder,
        Darkness
    }
    
    public enum Quest
    {
        None,
        Watering,
        Fertilizing,
        RemoveBugs,
        Cleaning
    }
}

namespace Game.FM
{
    public enum Phase
    {
        ConversationOne,
        ConversationTwo,
        ConversationThree,
        ConversationLast 
    }
}