# Floppy Bat

A Flappy Bird remake with a bat instead of a bird. Originally released on Google Play by Fryday Games; the app is no longer published.

> **Status: Archived.** This repository is kept for historical and reference purposes. It is not actively maintained, and no issues or pull requests will be reviewed.

## About

Floppy Bat is a simple tap-to-flap arcade game built in Unity. You control a bat that has to dodge pillars and rack up a score. The project includes the full game — gameplay scripts, menus, a color-selection system, audio, and AdMob integration that was used in the original release.

## Tech

- **Engine:** Unity `6000.4.1f1`
- **Language:** C#
- **Platforms:** Android (original release), should build for Standalone with ads disabled
- **Third-party:** Google Mobile Ads (AdMob), TextMesh Pro

## Getting started

1. Clone the repo.
2. Open the project folder in Unity Hub with Unity `6000.4.1f1` (or a compatible 6000.x version — Unity will offer to upgrade).
3. Open `Assets/Scenes` and press Play.

## Notes for anyone forking

- The AdMob app/unit IDs embedded in the project belong to the original publisher. If you plan to build and distribute, replace them with your own (or with [Google's test IDs](https://developers.google.com/admob/unity/test-ads)).
- Keystore, signing, and store-listing assets are not included.

## License

Released under the [MIT License](LICENSE). Third-party SDKs and packages (Google Mobile Ads, TextMesh Pro, etc.) remain under their own licenses.
