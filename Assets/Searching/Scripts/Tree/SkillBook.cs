using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tree
{

    public class SkillBook : MonoBehaviour
    {
        public SkillTree attackSkillTree;

        Skill attack;
        Skill fireStorm;
        Skill fireBall;
        Skill fireBlast;
        Skill fireWave;
        Skill fireExplosion;

        public void Start()
        {
            // build skill tree
            // └── Attack
            //     └── FireStorm
            //         ├── FireBlast
            //         └── FireBall
            //             └── FireWave
            //                 └── FireExplosion

            attack = new Skill("Attack");
            attack.isAvailable = true;

            fireStorm = new Skill("FireStorm");
            fireBall = new Skill("FireBall");
            fireBlast = new Skill("FireBlast");
            fireWave = new Skill("FireWave");
            fireExplosion = new Skill("FireExplosion");


            // 1. set the nextSkills for each skill

            // [0] Attack -> FireStorm

            // [1] FireStorm -> FireBlast

            // [2] FireStorm -> FireBall

            // [3] FireBall -> FireWave

            // [4] FireWave -> FireExplosion

            // [5] Attack -> FireStorm

            this.attackSkillTree = new SkillTree(attack);
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                // 2. call PrintSkillTreeHierarchy() or PrintSkillTree() on the root skill

                Debug.Log("====================================");
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                attack.Unlock();
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                fireStorm.Unlock();
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                fireBall.Unlock();
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                fireBlast.Unlock();
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                fireWave.Unlock();
            }
        }
    }

}