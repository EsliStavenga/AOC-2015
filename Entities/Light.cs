using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2015.Entities
{
    class Light
    {
        public int Brightness { get; private set;  }
        public LIGHT_TYPE lightType { get; private set; }
        public enum LIGHT_TYPE
        {
            STANDARD,
            DIMMABLE
        }

        public Light(int brightness = 0, LIGHT_TYPE type = LIGHT_TYPE.STANDARD) 
        {
            this.Brightness = brightness;
            this.lightType = type;
        }

        public void ExecuteCommand(string command)
        {
            if(command.ToLower().Trim() == "toggle")
            {
                this.ToggleState();
            } else
            {
                this.SetState(command);
            }
        }

        public bool IsOn()
        {
            return this.Brightness != 0;
        }

        public void SetState(string state)
        {
            state = state.ToLower().Trim();
            bool isOn = state == "on" || state == "turn on";

            if (this.lightType == LIGHT_TYPE.STANDARD)
            {
                this.Brightness = isOn ? 1 : 0;
            }
            else
            {
                int increment = isOn ? 1 : -1;

                this.Brightness = Math.Clamp(this.Brightness + increment, 0, int.MaxValue);
            }
        }

        public void ToggleState()
        {
            if (this.lightType == LIGHT_TYPE.STANDARD)
            {
                this.SetState(this.IsOn() ? "off" : "on");
            }
            else
            {
                this.Brightness += 2;
            }
        }

    }
}
