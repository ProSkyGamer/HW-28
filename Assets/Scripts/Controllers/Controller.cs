namespace Controllers
{
    public abstract class Controller
    {
        public bool IsActive { get; private set; }

        public virtual void TurnOn()
        {
            if (IsActive)
                return;

            IsActive = true;
        }

        public virtual void TurnOff()
        {
            if (IsActive == false)
                return;

            IsActive = false;
        }

        public void Update(float deltaTime)
        {
            if (IsActive == false)
                return;

            UpdateInternal(deltaTime);
        }

        protected abstract void UpdateInternal(float deltaTime);
    }
}