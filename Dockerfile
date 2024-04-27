FROM ubuntu:latest
LABEL authors="thorn"

ENTRYPOINT ["top", "-b"]
