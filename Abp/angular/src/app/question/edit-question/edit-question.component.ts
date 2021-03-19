import {Component, Injector,  OnInit,  EventEmitter,  Output,} from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { forEach as _forEach, includes as _includes, map as _map } from 'lodash-es';
import { AppComponentBase } from '@shared/app-component-base';
import {
  QuestionListDto,
  EditQuestionInput,
  QuestionServiceProxy,
  QuestionListDtoListResultDto,
} from '@shared/service-proxies/service-proxies';
@Component({
  selector: 'app-edit-question',
  templateUrl: './edit-question.component.html',
  styleUrls: ['./edit-question.component.css']
})
export class EditQuestionComponent   extends AppComponentBase
  implements OnInit {
  saving = false;
  id: number;
  quest:EditQuestionInput;
  grantedPermissionNames: string[];
  checkedPermissionsMap: { [key: string]: boolean } = {};

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    private _questService: QuestionServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._questService
      .getAllQuestionByID(this.id)
      .subscribe((result) => {
        this.quest =result.items[0];
       console.log(result.items[0]);
      });
  }

  save(): void {
    this.saving = true;
    this.quest.id=this.id;
    this.quest.topicId=this.quest.topicId;
    this._questService
      .updateQuestion(this.quest)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit();
      });
  }
}