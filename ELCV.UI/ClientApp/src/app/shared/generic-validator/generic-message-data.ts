import { IGenericMessage } from './generic-message';

export class GenericMessagesData {

  createData() {
    const genericMessagesData: IGenericMessage[] =
      [
        { code: "GEF", name: "Generic Error Form", errorMessage: "Please correct the validation errors." }
      ];
    return genericMessagesData;
  }


}
