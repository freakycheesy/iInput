using BoneLib;
using EyeTracking;
using EyeTracking.EyeGaze;
using MelonLoader;

namespace iInput {
    public class IInputTracking : EyeGazeImplementation {
        public override string Name => "iInput";
        public override string DeviceId => "electric.toaster";
        public override bool IsLoaded => true;

        public override void Initialize() {
            MelonLogger.Msg("Loaded");
        }
        public override void Update() {
            if (!Player.HandsExist)
                return;
            bool canGaze = Player.LeftController.GetThumbStickTouch() || Player.RightController.GetThumbStickTouch();
            Vector2 eyeGaze = new();
            if (canGaze) {
                var xGaze = Player.LeftController.GetThumbStickTouch() ? Player.LeftController.GetThumbStickAxis().x / 2f : Player.RightController.GetThumbStickAxis().x / 1.5f;
                var yGaze = Player.RightController.GetThumbStickAxis().y / 2.5f;
                eyeGaze = new(xGaze, yGaze);
            }
            Tracking.Data.Eye.Left.Gaze = eyeGaze;
            Tracking.Data.Eye.Right.Gaze = eyeGaze;

            Tracking.Data.Eye.Left.PupilDiameterMm = 5;
            Tracking.Data.Eye.Right.PupilDiameterMm = 5;
            float leftController = Mathf.Clamp(Player.LeftController.GetIndexCurlAxis() + Player.LeftController.GetMiddleCurlAxis(), 0, 1);
            float rightController = Mathf.Clamp(Player.RightController.GetIndexCurlAxis() + Player.RightController.GetMiddleCurlAxis(), 0, 1);
            float curl = leftController + rightController;
            float openness = 2.45f-curl;
            Tracking.Data.Eye.Left.Openness = openness;
            Tracking.Data.Eye.Right.Openness = openness;

            Tracking.Data.Eye.MinDilation = 0;
            Tracking.Data.Eye.MaxDilation = 10;
        }
    }
}