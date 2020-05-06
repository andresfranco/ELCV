import { GenericMessagesData } from './generic-message-data';

export class GenericValidationMessages {


  public generalFormValidationMessage(isFormValid): string {

    const genericErrorMessagesData = new GenericMessagesData();

    let genericErrorMessage = genericErrorMessagesData.createData().find(e => e.code == "GEF");
    if (genericErrorMessage.errorMessage || (isFormValid)) return "";
    if ((!isFormValid) && genericErrorMessage.errorMessage) return genericErrorMessage.errorMessage;
  }

}
