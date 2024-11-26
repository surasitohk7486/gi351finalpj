using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tree
{

    public class DialogueManager : MonoBehaviour
    {
        public DialogueTree tree;
        public DialogueNode currentNode;

        public void Start()
        {
            // 1. call LoadConversation() to set up the dialogue tree


            // 2. set the current node to the root of the tree and print its contents

        }

        private void LoadConversations()
        {
            // NPC: Ah, traveler! What brings you to this old place?
            //     |
            //     +-- [1] Can you give me a quest?
            //     |       |
            //     |       +-- NPC: I have a task for you. There’s a beast in the woods. Can you take care of it?
            //     |               |
            //     |               +-- [1] I’m ready for anything!
            //     |               |       |
            //     |               |       +-- NPC: You're not ready for this yet. Come back when you're stronger.
            //     |               |
            //     |               +-- [2] Maybe later.
            //     |                       |
            //     |                       +-- NPC: Safe travels, adventurer.
            //     |
            //     +-- [2] Where is the village?
            //     |       |
            //     |       +-- NPC: Follow the road south, and you’ll reach the village.
            //     |
            //     +-- [3] How do I get to the forest?
            //     |       |
            //     |       +-- NPC: Head west, into the forest. But beware, it's dangerous.
            //     |
            //     +-- [4] Goodbye.
            //             |
            //             +-- NPC: Safe travels, adventurer.

            // 3. Create the dialogue nodes
            DialogueNode greeting = new DialogueNode("Ah, traveler! What brings you to this old place?");
            DialogueNode askForQuest = new DialogueNode("I have a task for you. There’s a beast in the woods. Can you take care of it?");
            DialogueNode questDenied = new DialogueNode("You're not ready for this yet. Come back when you're stronger.");
            DialogueNode directionsVillage = new DialogueNode("Follow the road south, and you’ll reach the village.");
            DialogueNode directionsForest = new DialogueNode("Head west, into the forest. But beware, it's dangerous.");
            DialogueNode goodbye = new DialogueNode("Safe travels, adventurer.");
            DialogueNode noIdea = new DialogueNode("I'm afraid I can't help you with that.");

            // 4. Build the tree, adding custom responses ...

            // [1] add greeting's next node: askForQuest, with text: "Can you give me a quest?"

            // [2] add greeting's next node: directionsVillage, with text: "Where is the village?" 

            // [3] add greeting's next node: directionsForest, with text: "How do I get to the forest?" 

            // [4] add greeting's next node: goodbye, with text: "Goodbye."

            // [5] add askForQuest's next node: questDenied, with text: "I’m ready for anything!"

            // [6] add askForQuest's next node: goodbye, with text: "Maybe later."

            // 5. Set up the root of the dialogue tree

        }

        void Update()
        {
            int choice = -1;

            // 6. Handle player input to navigate the dialogue tree

            if (choice != -1)
            {
                // 7. Update the current node based on the player's choice

            }
        }
    }

}