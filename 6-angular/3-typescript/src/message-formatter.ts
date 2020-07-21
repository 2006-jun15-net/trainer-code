import Message from "./message";

export default interface MessageFormatter {
  format(message: Message): string;
}
