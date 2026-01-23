import { NgModule } from "@angular/core";
import { ButtonsModule } from "./buttons/buttons.module";
import { InputsModule } from "./inputs/inputs.module";
import { SideBar } from './side-bar/side-bar';
import { Room } from './room/room';
import { Message } from './message/message';
import { BrowserModule } from "@angular/platform-browser";
import { CommonModule } from "@angular/common";
import { AddMember } from "./add-member/add-member";



@NgModule({
    declarations: [
    SideBar,
    Room,
    Message,
    AddMember
,
  ],
    imports: [ButtonsModule, InputsModule, BrowserModule, CommonModule],
    exports: [ButtonsModule,InputsModule,SideBar, Room, CommonModule, Message, AddMember],
})
export class ComponentsModule {}