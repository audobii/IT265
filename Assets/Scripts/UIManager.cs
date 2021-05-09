using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

/* Todo list
 * organize functions
 * find way to make answer checking more optimal?
 */

public class UIManager : MonoBehaviour
{
    public GameObject slot;
    [Header("Title Scene Properties", order = 0)]
    [Space(2f)]
    [Header("Intro Scene Properties", order = 1)]
    public TMP_Text introText;
    public GameObject introImage;
    public GameObject backButton;
    public GameObject nextButton;
    [Header("Tutorial Scene Properties", order = 2)]
    [Space(2f)]
    public TMP_Text tutorialIntroTitleText;
    public TMP_Text tutorialIntroText;
    public TMP_Text tutText;
    public GameObject beginTutorialButton;
    public GameObject tutBackButton;
    public GameObject tutNextButton;
    public GameObject imageBits;
    public GameObject imageLogicGateEx;
    public GameObject imageTruthTables;
    public GameObject imageLogicGates;
    public GameObject andGateT;
    public GameObject orGateT;
    public GameObject emptySlotT;
    public GameObject gatePiecesT;
    public GameObject goButtonT;
    public GameObject incorrectOverlay;
    public GameObject overlay;
    public GameObject tutTextBox;
    public GameObject tutTextBoxNextButton;
    public GameObject tutTextBoxBackButton;
    [Header("Level01 Scene Properties", order = 3)]
    public TMP_Text levelIntroText;
    public TMP_Text taskText;
    public TMP_Text inputText1;
    public TMP_Text inputText2;
    public TMP_Text outputText;
    public TMP_Text explanationText;
    public GameObject startButton;
    public GameObject goButton;
    public GameObject hintButton;
    public GameObject andGate;
    public GameObject orGate;
    public GameObject notGate;
    public GameObject emptySlot;
    public GameObject gatePieces;
    public GameObject hintScreen;
    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject output0;
    public GameObject output1;

    int introSequenceCount;
    int tutorialSequenceCount;
    int levelSequenceCount;
    int tutTextCount;
    Vector3 andGateDefaultPos;
    Vector3 orGateDefaultPos;
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
                InitializeTutorial();
                break;
            case "03Level01Scene":
                InitializeLevel();
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

    public void TutorialSequenceBack()
    {
        tutorialSequenceCount--;
        SetTutorialSequence();
    }

    public void TutorialSequenceNext()
    {
        tutorialSequenceCount++;
        SetTutorialSequence();
    }

    public void TutorialTextBack()
    {
        tutTextCount--;
        TutTextCycle();
    }

    public void TutorialTextNext()
    {
        tutTextCount++;
        TutTextCycle();
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

    public void SetTutorialSequence()
    {
        incorrectOverlay.SetActive(false);
        switch(tutorialSequenceCount)
        {
            case 0:
                InitializeTutorial();
                break;
            case 1:
                tutorialIntroText.fontSize = 22;
                tutorialIntroTitleText.text = "First, let's go over the concept of \"bits\"!";
                tutorialIntroText.text = "\n\n\n\n\n\nA bit is the smallest unit of storage on the computer. \"Bit\" is short for binary digit.\n" +
                    "Bits have a value of either 0 or 1. It can only have one of these two states.\n" +
                    "It's like how something can be either on or off, open or closed, true or false - bits are either 0 or 1.\n" +
                    "Used together, bits can be used to store or communicate information, or various other things.";
                beginTutorialButton.SetActive(false);
                tutNextButton.SetActive(true);
                tutBackButton.SetActive(false);
                imageBits.SetActive(true);
                imageLogicGateEx.SetActive(false);
                break;
            case 2:
                tutorialIntroText.fontSize = 22;
                tutorialIntroTitleText.text = "Next, let's look at logic gates.";
                tutorialIntroText.text = "\n\n\n\nLogic gates help electronic devices do their tasks, which can be complex. In a way, they help computers \"think\" by using logic and making it easier to do what they need to.\n" +
                    "\nA logic gate takes in some bits as an input. It will then output one bit based on these inputs.\n" +
                    "You can picture it as a machine that takes in bits, looks at them, and spits out one bit for you to have.";
                tutBackButton.SetActive(true);
                imageBits.SetActive(false);
                imageLogicGateEx.SetActive(true);
                imageLogicGates.SetActive(false);
                break;
            case 3:
                tutorialIntroTitleText.text = "Here are some examples of logic gates!";
                tutorialIntroText.text = "\n\n\n\nAND gates output 1 if and only if both inputs are 1. Otherwise, it will output a 0." +
                    "\nOR gates output 1 when at least one input is 1. Otherwise, it will output a 0." + 
                    "\nNOT gates will output the opposite of their input. They INVERSE their input. So, if the input is 1, it will output 0, and vice versa.";
                imageLogicGateEx.SetActive(false);
                imageTruthTables.SetActive(false);
                imageLogicGates.SetActive(true);
                break;
            case 4:
                tutorialIntroText.fontSize = 22;
                tutorialIntroTitleText.text = "Truth tables can help you understand and predict the output of certain logic gate matchups.";
                tutorialIntroText.text = "\n\nDepending on the input, logic gates will give a certain output. Truth tables show you the different combinations of inputs and the output based on the logic gate. Here are some examples using the logic gates we already talked about!";
                imageTruthTables.SetActive(true);
                imageLogicGates.SetActive(false);
                break;
            case 5:
                tutorialIntroText.fontSize = 32;
                tutorialIntroTitleText.text = "Let's put it all together!";
                tutorialIntroText.text = "\n\n\nIn this game, we will be making \"logic machines\"! These logic machines will help you learn how to use bits and logic gates together. Click the \"next\" button to continue!";
                imageTruthTables.SetActive(false);
                tutBackButton.SetActive(true);
                break;
            case 6:
                //show how to use the game
                gatePiecesT.SetActive(true);
                andGateT.SetActive(true);
                orGateT.SetActive(true);
                emptySlotT.SetActive(true);
                goButtonT.SetActive(true);
                tutTextBox.SetActive(true);
                tutBackButton.SetActive(false);
                tutNextButton.SetActive(false);
                incorrectOverlay.SetActive(false);
                tutTextBoxNextButton.SetActive(true);
                tutTextBoxBackButton.SetActive(false);
                overlay.SetActive(true);
                tutorialIntroTitleText.text = "";
                tutorialIntroText.text = "";
                tutText.text = "This is what the game looks like! Below is a \"logic machine\" you need to help put together. The input and output bits are already there for you at the right and left respectively. The logic gates AND and OR are at the bottom.";
                break;
            case 7:
                gatePiecesT.SetActive(false);
                andGateT.SetActive(false);
                orGateT.SetActive(false);
                emptySlotT.SetActive(false);
                goButtonT.SetActive(false);
                tutTextBox.SetActive(false);
                tutNextButton.SetActive(true);
                tutorialIntroTitleText.text = "That's correct!";
                tutorialIntroText.text = "\n\n\n\nEither logic gate would have been correct.\n" +
                    "For the AND gate, both input bits were NOT 1, so it would output a 0 in this case.\n" +
                    "For the OR gate, there needs to be at least one input bit that is 1, but both were 0 in this case, so it would output 0 as well.\n" +
                    "Click the next button to continue.";
                break;
            case 8:
                //congrats u finished tutorial
                tutNextButton.SetActive(false);
                tutorialIntroTitleText.text = "Congratulations! You finished the tutorial!";
                tutorialIntroText.text = "\n\n\nYou're ready to play the game. Press the home button to go back to the menu and play Level 01. Feel free to come back to this tutorial at any time if you need help!";
                break;
        }
    }

    void InitializeIntro()
    {
        introText.fontSize = 24;
        introText.horizontalAlignment = HorizontalAlignmentOptions.Center;
        introText.text = "Welcome to Logic Gate Game!\n\n" +
            "Learn about logic gates by putting together \"logic machines\" of your own!" +
            "(Remember, there can be more than one correct answer!)";
        introImage.SetActive(true);
        backButton.SetActive(false);
    }

    void InitializeTutorial()
    {
        tutorialIntroText.fontSize = 32;
        tutorialIntroTitleText.text = "Welcome to the tutorial!";
        tutorialIntroText.text = "Before playing the game, let's go over some basic concepts and how to play!";
        beginTutorialButton.SetActive(true);
        tutNextButton.SetActive(false);
        tutBackButton.SetActive(false);
        imageBits.SetActive(false);
        imageLogicGateEx.SetActive(false);
        imageTruthTables.SetActive(false);
        imageLogicGates.SetActive(false);
        gatePiecesT.SetActive(false);
        andGateT.SetActive(false);
        orGateT.SetActive(false);
        emptySlotT.SetActive(false);
        goButtonT.SetActive(false);
        incorrectOverlay.SetActive(false);
        overlay.SetActive(false);
    }

    void InitializeLevel()
    {
        goButton.SetActive(false);
        hintButton.SetActive(false);
        andGate.SetActive(false);
        orGate.SetActive(false);
        notGate.SetActive(false);
        emptySlot.SetActive(false);
        gatePieces.SetActive(false);
        output0.SetActive(false);
        output1.SetActive(false);
        andGateDefaultPos = andGate.GetComponent<RectTransform>().position;
        orGateDefaultPos = orGate.GetComponent<RectTransform>().position;
    }

    //set up first exercise
    public void BeginLevel()
    {
        goButton.SetActive(true);
        hintButton.SetActive(true);
        startButton.SetActive(false);
        levelIntroText.text = "";
        SetLevelExercise();
    }

    // used to check if tutorial was completed correctly
    public void CheckTutorial()
    {
        string currGate = slot.GetComponent<Slot>().currentGate;
        if(currGate.Equals("GateOr") || currGate.Equals("GateAnd"))
        {
            tutorialSequenceCount++;
            SetTutorialSequence();
        } else
        {
            incorrectOverlay.SetActive(true);
        }
    }

    public void TutTextCycle()
    {
        switch(tutTextCount)
        {
            case 0:
                tutText.text = "This is what the game looks like! Below is a \"logic machine\" you need to help put together. The input and output bits are already there for you at the right and left respectively. The logic gates AND and OR are at the bottom.";
                tutTextBoxNextButton.SetActive(true);
                tutTextBoxBackButton.SetActive(false);
                break;
            case 1:
                tutText.text = "This machine is incomplete. Our input is two bits that are both 0, and our output is also 0. Use your previous knowledge to finish this logic machine! (There can be more than one right answer!)";
                tutTextBoxNextButton.SetActive(true);
                tutTextBoxBackButton.SetActive(true);
                break;
            case 2:
                tutText.text = "To complete this logic machine, use your Left Mouse Button to click, hold, and drag one of the logic gates to the empty slot with a question mark in the middle. To remove it, click and drag again and move it outside of the slot.";
                tutTextBoxNextButton.SetActive(true);
                tutTextBoxBackButton.SetActive(true);
                break;
            case 3:
                tutText.text = "Good luck! When you're ready, click the GO! button to check your work.";
                tutTextBoxNextButton.SetActive(false);
                tutTextBoxBackButton.SetActive(true);
                overlay.SetActive(false);
                break;
        }
    }

    /* checks if current exercise is done correctly
     * if not, restart exercise
     * if so, show congratulations screen and set up next exercise
     */
    public void CheckWork()
    {
        string currGate = slot.GetComponent<Slot>().currentGate;
        switch(levelSequenceCount)
        {
            case 0:
                //right answer
                if (currGate.Equals("GateOr"))
                {
                    Debug.Log("Correct!");
                    levelSequenceCount++;
                    explanationText.text = "OR is the correct gate since using AND requires both inputs to be 1 in order to output 1.\n" +
                        "With the OR gate, you only need one input to be 1 to output 1.";
                    winScreen.SetActive(true);
                }
                //else if wrong answer
                else
                {
                    Debug.Log("Incorrect");
                    loseScreen.SetActive(true);
                }
                break;
            case 1:
                if (currGate.Equals("GateAnd") || currGate.Equals("GateOr"))
                {
                    Debug.Log("Correct!");
                    levelSequenceCount++;
                    explanationText.text = "Either the AND or OR gate can work here, since both inputs are 1.\n" +
                        "An AND gate will give 1 only when both inputs are 1. As long as either input is 1, OR works too.";
                    winScreen.SetActive(true);
                }
                //else if wrong answer
                else
                {
                    Debug.Log("Incorrect");
                    loseScreen.SetActive(true);
                }
                break;
            case 2:
                if (currGate.Equals("GateAnd"))
                {
                    Debug.Log("Correct!");
                    levelSequenceCount++;
                    explanationText.text = "AND is the correct gate since using OR would output a 1 (because if at least one input is 1 and our gate is OR, our output will be 1).\n" +
                        "Here we wanted our output to be 0, and since both inputs aren't 1, we will get a 0 from using an AND gate.";
                    winScreen.SetActive(true);
                }
                //else if wrong answer
                else
                {
                    Debug.Log("Incorrect");
                    loseScreen.SetActive(true);
                }
                break;
            case 3:
                break;
        }
    }

    //display hint to player
    public void ShowHint()
    {
        hintScreen.SetActive(true);
    }

    //return to game, exit hint
    public void ExitHint()
    {
        hintScreen.SetActive(false);
    }

    public void SetLevelExercise()
    {
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
        andGate.transform.position = andGateDefaultPos;
        orGate.transform.position = orGateDefaultPos;
        switch (levelSequenceCount)
        {
            case 0:
                //first exercise - inputs 0,1 / output 1 / answer: OR gate
                taskText.text = "Using the input and output provided below, please place the correct logic gate in the empty ? space to complete the circuit so it produces the desired output.";
                inputText1.text = "0";
                inputText2.text = "1";
                //outputText.text = "1";
                output0.SetActive(false);
                output1.SetActive(true);
                andGate.SetActive(true);
                orGate.SetActive(true);
                gatePieces.SetActive(true);
                emptySlot.SetActive(true);
                break;
            case 1:
                //second exercise - inputs 1,1 / output 1 / answer: AND gate or OR gate
                inputText1.text = "1";
                inputText2.text = "1";
                //outputText.text = "1";
                output0.SetActive(false);
                output1.SetActive(true);
                andGate.SetActive(true);
                orGate.SetActive(true);
                break;
            case 2:
                //third exercise - inputs 1,0 / output 0 / answer: AND gate
                taskText.text = "Using the input and output provided below, please place the correct logic gate in the empty ? space to complete the circuit so it produces the desired output. (Pay attention to the output this time!)";
                inputText1.text = "1";
                inputText2.text = "0";
                //outputText.text = "0";
                output0.SetActive(true);
                output1.SetActive(false);
                break;
            case 3:
                //end
                levelIntroText.text = "Thanks for playing!";
                taskText.text = "";
                inputText1.text = "";
                inputText2.text = "";
                outputText.text = "";
                goButton.SetActive(false);
                hintButton.SetActive(false);
                andGate.SetActive(false);
                orGate.SetActive(false);
                notGate.SetActive(false);
                emptySlot.SetActive(false);
                gatePieces.SetActive(false);
                output0.SetActive(false);
                output1.SetActive(false);
                break;
        }
    }
}
