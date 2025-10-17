# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## Unreleased

### Added

- RotationSensorDefinition, which measures how quickly single bones are rotating.
- FootstepSensorDefinition, which can detect foot down/up events, as well as measure ground proximity.
- All of these can be used:
  - Standalone, providing a globally-visible parameter
  - In a ProceduralController