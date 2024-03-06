using System;

namespace TVs
{
    public interface ILEDTV
    {
        void SwitchOn();

        void SwitchOff();

        void SetChannel(int channelNumber);
    }

    public class SamsungLEDTV : ILEDTV
    {
        public void SwitchOn()
        {
            Console.WriteLine($"Turning ON : {GetType().Name}");
        }

        public void SwitchOff()
        {
            Console.WriteLine($"Turning OFF : {GetType().Name}");
        }

        public void SetChannel(int channelNumber)
        {
            Console.WriteLine($"Setting channel number {channelNumber} on {GetType().Name}");
        }
    }

    public class SonyLEDTV : ILEDTV
    {
        public void SwitchOn()
        {
            Console.WriteLine($"Turning ON : {GetType().Name}");
        }

        public void SwitchOff()
        {
            Console.WriteLine($"Turning OFF : {GetType().Name}");
        }

        public void SetChannel(int channelNumber)
        {
            Console.WriteLine($"Setting channel number {channelNumber} on {GetType().Name}");
        }
    }

    public abstract class AbstractRemoteControl
    {
        protected ILEDTV ledTV;

        protected AbstractRemoteControl(ILEDTV ledTV)
        {
            this.ledTV = ledTV;
        }

        public abstract void SwitchOn();

        public abstract void SwitchOff();

        public abstract void SetChannel(int channelNumber);
    }

    public class SamsungRemoteControl : AbstractRemoteControl
    {
        public SamsungRemoteControl(ILEDTV ledTV) : base(ledTV)
        {

        }

        public override void SwitchOn()
        {
            ledTV.SwitchOn();
        }

        public override void SwitchOff()
        {
            ledTV.SwitchOff();
        }

        public override void SetChannel(int channelNumber)
        {
            ledTV.SetChannel(channelNumber);
        }
    }

    public class SonyRemoteControl : AbstractRemoteControl
    {
        public SonyRemoteControl(ILEDTV ledTV) : base(ledTV)
        {

        }

        public override void SwitchOn()
        {
            ledTV.SwitchOn();
        }

        public override void SwitchOff()
        {
            ledTV.SwitchOff();
        }

        public override void SetChannel(int channelNumber)
        {
            ledTV.SetChannel(channelNumber);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            ILEDTV samsungLEDTV = new SamsungLEDTV();
            AbstractRemoteControl samsungRemoteControl = new SamsungRemoteControl(samsungLEDTV);
            samsungRemoteControl.SwitchOn();
            samsungRemoteControl.SetChannel(9);
            samsungRemoteControl.SwitchOff();

            Console.WriteLine();

            ILEDTV sonyLEDTV = new SonyLEDTV();
            AbstractRemoteControl sonyRemoteControl = new SonyRemoteControl(sonyLEDTV);
            sonyRemoteControl.SwitchOn();
            sonyRemoteControl.SetChannel(21);
            sonyRemoteControl.SwitchOff();
        }
    }
}