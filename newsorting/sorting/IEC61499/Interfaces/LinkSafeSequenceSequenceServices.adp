<?xml version='1.0' encoding='utf-8'?>
<AdapterType Name="LinkSafeSequenceSequenceServices" Namespace="Main" GUID="7677e7b4-7ae6-44ce-9b9d-5b32896be5d4">
  <Identification Standard="61499-2" />
  <VersionInfo Organization="sorting2n" Version="3.0" Author="sorting2n" Date="2026-11-12" />
  <InterfaceList>
    <EventInputs>
      <Event Name="FromServices_Home_INITO" ID="199423B8E3EA424D">
        <With Var="FromServices_Home_HomeReady" />
      </Event>
      <Event Name="FromServices_Ownership_CNF" ID="8705939D5B1442EC">
        <With Var="FromServices_Ownership_AllLocal" />
      </Event>
      <Event Name="FromServices_Home_CNF" ID="F3737632F0674E5B">
        <With Var="FromServices_Home_HomeReady" />
      </Event>
    </EventInputs>
    <EventOutputs>
      <Event Name="ToSequence_TakeOwnership_STEP_ENTER" ID="011CF67C6620420F" />
      <Event Name="ToSequence_CommandInitialPosition_STEP_ENTER" ID="A7B722B3D101427D" />
      <Event Name="ToSequence_WaitInitialPosition_STEP_ENTER" ID="8F745BA862BE446D" />
      <Event Name="ToSequence_InitialSettle_EO" ID="DE074F0018CA41B7" />
    </EventOutputs>
    <InputVars>
      <VarDeclaration Type="BOOL" Name="FromServices_Ownership_AllLocal" ID="B0172C60E5884E40" />
      <VarDeclaration Type="BOOL" Name="FromServices_Home_HomeReady" ID="A973A7B0624E4A64" />
    </InputVars>
  </InterfaceList>
</AdapterType>