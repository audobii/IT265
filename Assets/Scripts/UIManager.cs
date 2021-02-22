using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Title Scene Properties", order = 0)]
    [Space(2f)]
    [Header("Intro Scene Properties", order = 1)]
    public TMP_Text introText;
    public GameObject introImage;
    public GameObject backButton;
    public GameObject nextButton;
    [Header("Tutorial Scene Properties", order = 2)]
    [Space(2f)]
    [Header("Level01 Scene Properties", order = 3)]

    int introSequenceCount;
    Scene currentScene;

    private void Start()
    {

    }

    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
        
        switch(currentScene.name)
        {
            case "00TitleScene":
                break;
            case "01IntroScene":
                InitializeIntro();
                break;
            case "02TutorialScene":
                break;
            case "03Level01Scene":
                break;
        }
    }

    public void SetScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void IntroSequenceBack()
    {
        introSequenceCount--;
        SetIntroSequence();
    }

    public void IntroSequenceNext()
    {
        introSequenceCount++;
        SetIntroSequence();
    }

    void SetIntroSequence()
    {
        switch (introSequenceCount)
        {
            case 0:
                InitializeIntro();
                break;
            case 1:
                introImage.SetActive(false);
                backButton.SetActive(true);
                introText.horizontalAlignment = HorizontalAlignmentOptions.Left;
                introText.text = "OVERVIEW\n\n" +
                    "Title: Logic Gate Game\n" +
                    "Platform: WebGL build\n" +
                    "Subject: Science\n" +
                    "Sub Subject: Computer Science\n" +
                    "Main Focus: Logic Gates\n" +
                    "Learning Level: 6-8th grade"
                    ;
                break;
            case 2:
                introText.fontSize = 24;
                introText.text = "PROPOSED EDTECH SOLUTION\n\n" +
                    "Computer science continues to grow in popularity and importance as the years go by and more and more students seem to be showing interest in the field. However, younger students may find it hard to get into the field, as it might seem intimidating or daunting to some at first. Computer science might not even have a place in their school’s curriculum, making it harder for them to access or be introduced to the topic. In order to aid them, I propose an easy-to-use and easy-to-understand game that helps them learn about logic gates, which can look more complicated than it actually is. The game can be in a minigame format where they need to assemble a certain “logic machine” with a specific output given certain pieces (like AND gates, OR gates, and input such as 0 and 1) and drag/place them together or pick the correct pieces, somewhat like a puzzle game where they figure out how logic gates work. It can be an introduction to logic gates, simplified for them to understand at a young age but educational enough for them to retain what they learn and use it when the concepts get more complex. This hopefully serves as just one building block in their computer science journey."
                    ;
                break;
            case 3:
                introText.fontSize = 17;
                introText.text = "COMPETING SOFTWARE REVIEW\n\n" +
                    "Khan Academy - A nonprofit, educational website with lessons on various topics for students of all ages. This specific lesson on logic gates has articles to read and quiz problems to test what the user has learned. A user doesn’t need to create an account to access and use the content, but needs one in order to save and track their progress or get personalized help if so desired.\n\n" +
                    "Minecraft (Education Edition) - A widely popular sandbox video game’s educational version of the game. Free demo/trial available for teachers and their students, but might need to pay or be eligible for accessing the full edition. Minecraft has its own programming system in game via redstone. Students can build redstone circuits and play around with the assortment of redstone items. Very interactive and engaging as students have the freedom to build their contraptions and environments and interact with them. They can learn about logic gates and various other topics through redstone in conjunction with guided lesson plans.\n\n" +
                    "Nandgame - A web browser game that serves as an exercise aimed at older students (high school/college) or older people looking to learn about logic gates and building computers. Based off of a course called “From NAND to Tetris - Building a Modern Computer From First Principles”. Nandgame itself has users slowly progress through its levels, each one having them make a certain component (like an inverter or AND gate) using previous components. Aptly named, as the first component the user is given to build with is a NAND gate. It becomes more complex as it transitions from making logic gates to building a CPU."
                    ;
                break;
            case 4:
                introText.fontSize = 24;
                introText.text = "COMPETING SOFTWARE SUGGESTED IMPROVEMENTS\n\n" +
                    "Learnability - Less clunky/overwhelming/hard-to-follow instructions. Built-in guide, clearer instructions, and additional guidance. Maybe addition of better tips or hints.\n\n" +
                    "Engagement - Visuals that are interesting and easy to look at. Interactive and visually appealing scenes and assets could keep students engaged and excited for a topic that could be difficult to grasp or be interested in. Reward/win screen that boldly presents itself to congratulate the student clearly and reinforces engagement.\n\n" +
                    "Clarification/Reinforcement of concepts - More explanation needed for certain levels or concepts. Repeat or have similar iterations of certain problems in order to reinforce what they learn. Expand on types of questions to explore more of the concept. "
                    ;
                break;
            case 5:
                introText.text = "STAKEHOLDERS\n\n" +
                    "Teachers\n" +
                    "Parents\n" +
                    "Students\n\n" +
                    "USERS\n\n" +
                    "Middle school students (6-8th graders)"
                    ;
                break;
            case 6:
                introText.text = "PERSONA\n\n" +
                    "Name: Fiona\n" +
                    "Age: 13\n" +
                    "Gender: Female\n" +
                    "Location: Suburbia USA\n" +
                    "Personal Notes:\n" +
                    "     Enjoys computer games\n" +
                    "     Is tech-savvy\n" +
                    "Student Notes:\n" +
                    "     Struggles with conceptual computer science topics and basics\n" +
                    "     Struggles with written tests and quizzes\n" +
                    "     Likes computer lab classes\n" +
                    "     Needs to work with visuals/hands-on examples since abstract concepts are hard to grasp"
                    ;
                break;
            case 7:
                introText.text = "PERSONA JUSTIFICATION\n\n" +
                    "Having worked with K-6 students before and having been a middle school student with a brief look into the world of computer science, I created this persona based on familiarity and my past experiences. Fiona represents the potential users of this game: middle schoolers with an interest in or even little knowledge with computer science but limited access to relevant learning resources. I chose this persona because CS is a subject that is very quickly becoming more and more popular yet it is difficult to get into, especially at younger ages. Also computer science classes are not as common in lower grades when they could be at the same level as foreign language classes, or rather they can be not part of the core curriculum but an optional extension of it if students are interested."
                    ;
                break;
            case 8:
                introText.fontSize = 24;
                introText.text = "PROBLEM SCENARIO\n\n" +
                    "Fiona thinks she’s pretty interested in computers and coding, but her school doesn’t really offer much in terms of computer science classes. They have a computer lab where some classes take place. Although they had a brief introduction to programming through Scratch, they didn’t really learn much in terms of computer science topics/coding, just how to use the internet and tools like Google Docs. She doesn’t know where to start and doesn’t seem to have much resources available to her at school that can introduce her to computer science-related topics.\n\n" +
                    "Fiona enjoys watching Youtube videos and playing Minecraft after school, and stumbles across some videos about using redstone in Minecraft. She thinks the things people build with redstone are really cool but is overwhelmed and doesn’t know where to start learning about this fairly complicated system. Frustrated, she just continues watching instead of doing, and doesn’t try to further her knowledge or satiate her curiosity."
                ;
                break;
            case 9:
                introText.fontSize = 22;
                nextButton.SetActive(true);
                introText.text = "ACTIVITY SCENARIO\n\n" +
                    "One day, Fiona’s parents, knowing her love for games, introduce her to one she might be interested in - one where she can easily start learning about logic gates while being able to stay engaged in the topic. They think it can help her get a headstart in CS before she moves on to more complex topics in the future. At first, Fiona is a bit hesitant because it isn’t exactly like the games she likes at the moment, but she decides to try it anyway.\n\n" +
                    "Fiona finds herself able to pick up on the basics of logic gates, thanks to this game being interactive enough for her to feel like she can understand the information without feeling like she’s taking a test. She likes being able to interact with the different pieces and is able to see the result of her actions right away, which feels rewarding to her. She realizes logic gates and things like redstone don’t have to be so complicated after all, and with her newfound knowledge she is able to apply it to simple redstone projects in her Minecraft world. Fiona decides she wants to continue her education in computer science in the future, but for now will have fun with her games and whatever she can find on the internet."
                    ;
                break;
            case 10:
                introText.fontSize = 24;
                nextButton.SetActive(false);
                introText.text = "PROBLEM STATEMENT\n\n" +
                    "Fiona is interested in computer science but feels a bit deterred by the abstract concepts and logic surrounding it, somewhat intimidated due to a lack of a proper introduction to any computer science-related topic. She finds herself not knowing some basics and doesn’t have an easy way to learn some building blocks before she gets into more complicated topics. She needs something that’s easy to understand/use and engaging that can show her a simplified version of what could be a complicated topic while teaching her an important building block in CS. After being introduced to just a small part of computers, Fiona wants to learn more. She is inspired and feels comfortable in pursuing a computer science education in the future."
                    ;
                break;
        }
    }

    void InitializeIntro()
    {
        introText.fontSize = 24;
        introText.horizontalAlignment = HorizontalAlignmentOptions.Center;
        introText.text = "Welcome to Logic Gate Game!\n\n" +
            "Learn about logic gates by putting together \"logic machines\" of your own!";
        introImage.SetActive(true);
        backButton.SetActive(false);
    }
}
