import MessageFormatter from "./message-formatter";
import Message from "./message";

export default class FancyMessageFormatter implements MessageFormatter {
  format(message: Message) {
    return `~~~ ${message.text} from ${message.author} ~~~`;
  }
}
