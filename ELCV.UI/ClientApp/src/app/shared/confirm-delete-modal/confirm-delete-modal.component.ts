import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { IConfirmDeleteModal } from "./ConfirmDeleteModal";
import { GenericMessages } from '../generic-messages/generic-messages';
import { GenericLabels } from '../generic-labels/generic-labels';
import { ConfirmDeleteModalLabel } from './ConfirmDeleteModalLabel';
@Component({
  selector: 'confirm-delete-modal',
  templateUrl: './confirm-delete-modal.component.html',
  styleUrls: ['./confirm-delete-modal.component.css']
})
export class ConfirmDeleteModalComponent implements OnInit {

  @Input() modalData: IConfirmDeleteModal;
  public genericMessages = new GenericMessages();
  public genericLabels = new GenericLabels();
  public modalLabels = new ConfirmDeleteModalLabel();
  
  constructor(public modal: NgbActiveModal) {
  
    
  }
    ngOnInit(): void {
      if (!this.modalData.deleteQuestion) this.modalData.deleteQuestion = this.genericMessages.modalConfirmMessages.deleteQuestion;
      if (!this.modalData.deletPrincipalMessage) this.modalData.deletPrincipalMessage = this.genericMessages.modalConfirmMessages.deletPrincipalMessage;
      if (!this.modalData.deleteSecondaryMessage) this.modalData.deleteSecondaryMessage = this.genericMessages.modalConfirmMessages.deleteSecondaryMessage;
      this.modalLabels.confirmDeleteButtonLabel = this.genericLabels.modalConfirmLabels.confirmDeleteButtonLabel;
      this.modalLabels.cancelButtonLabel = this.genericLabels.modalConfirmLabels.cancelButtonLabel;
    }

  onConfirm() {

    this.modal.close('delete');
    
  }
  onCancel() {
    this.modal.dismiss();
  }

 
  
}
