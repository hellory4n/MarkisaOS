namespace markisa.network {

class PassionfruitSupportConvrs1
{

public static MksConversation Data { get; set; } = new MksConversation {
    Messages = new MksMessage[] {
        new MksMessage {
            User = "Passionfruit Support",
            Content = "Hello! How can I help you?",
            ReplyChoices = new MksMessageReply[] {
                new MksMessageReply {
                    ChoiceText = "My device won't worky :(",
                    Messages = new MksMessage[] {
                        new MksMessage {
                            User = "You",
                            Content = "My device won't worky :("
                        },

                        new MksMessage {
                            User = "Passionfruit Support",
                            Content = "Sounds like a skill issue. Have you tried turning it on and off again?",
                            ReplyChoices = new MksMessageReply[] {
                                new MksMessageReply {
                                    ChoiceText = "Yes",
                                    Messages = new MksMessage[] {
                                        new MksMessage {
                                            User = "You",
                                            Content = "Yes I did."
                                        },

                                        new MksMessage {
                                            User = "Passionfruit Support",
                                            Content = "Oh fuck off then"
                                        }
                                    }
                                },

                                new MksMessageReply {
                                    ChoiceText = "No",
                                    Messages = new MksMessage[] {
                                        new MksMessage {
                                            User = "You",
                                            Content = "No, I will try that."
                                        },

                                        new MksMessage {
                                            User = "Passionfruit Support",
                                            Content = "Did it work?",
                                            ReplyChoices = new MksMessageReply[] {
                                                new MksMessageReply {
                                                    ChoiceText = "Yes",
                                                    Messages = new MksMessage[] {
                                                        new MksMessage {
                                                            User = "You",
                                                            Content = "Yes, it did work."
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
};

}

}