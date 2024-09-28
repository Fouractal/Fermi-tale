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

    public enum MainRoom_Phase
    {
        Start,
        MovementGuide,
        RotationGuide,
        InteractionGuide,
        End
    }
    public enum Scene
    {
        MN,
        FD,
        LV,
        FM, 
        ST,
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
        ConversationLast 
    }
}