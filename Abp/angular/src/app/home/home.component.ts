import { Component, Injector, ChangeDetectionStrategy, ChangeDetectorRef, } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { TopicListDto, 
  TopicServiceProxy,
  QuestionListDto,
  QuestionServiceProxy,UserServiceProxy,
  UserDto,AnswerServiceProxy, AnswerListDto } from '@shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';

@Component({
  templateUrl: './home.component.html',
  animations: [appModuleAnimation()],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class HomeComponent extends AppComponentBase {

  topics: TopicListDto[] = [];
  topicLength:number;
  questions: QuestionListDto[] = [];
  questionLength:number;
  users: UserDto[] = [];
  userLength:number;
  answers: AnswerListDto[] = [];
  answerLength:number;




  constructor(injector: Injector,
    private _topicService: TopicServiceProxy,
    private _questService: QuestionServiceProxy,
    private _userService: UserServiceProxy,
    private _answerService: AnswerServiceProxy,

    private changeDetection: ChangeDetectorRef
    ) {
    super(injector);
  }

  ngOnInit() {
    this.getAllTopics();
    this.getAllQuestion();
    //this.getAllUser();
     this.getAllAnswer();
  }

    getAllTopics(){
      this._questService.getAllQuestion()
      .pipe(
       finalize(() => {
         console.log("Error")
         // finishedCallback();
       })
     )
      .subscribe( data => { 
        console.log(data)
        this.questions=data.items;
        this.questionLength= data.items.length;
        this.changeDetection.detectChanges();
        console.log(this.questionLength)
      });
   
     }

     getAllQuestion(){
      this._topicService.getAllTopics()
      .pipe(
       finalize(() => {
         console.log("Error")
         // finishedCallback();
       })
     )
      .subscribe( data => { 
        console.log(data)
        this.topics=data.items;
        this.topicLength= data.items.length;
        this.changeDetection.detectChanges();
        console.log(this.topicLength)
      });
   
     }
     getAllAnswer(){
      this._answerService.getAllAnswer()
      .pipe(
       finalize(() => {
         console.log("Error")
         // finishedCallback();
       })
     )
      .subscribe( data => { 
        console.log(data)
        this.answers=data.items;
        this.answerLength= data.items.length;
        this.changeDetection.detectChanges();
        console.log(this.answerLength)
      });
   
     }

     
  

}
