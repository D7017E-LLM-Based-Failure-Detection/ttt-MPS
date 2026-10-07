<?xml version="1.0" encoding="utf-8"?>
<!DOCTYPE AdapterType SYSTEM "../LibraryElement.dtd">
<AdapterType GUID="c94ace26-a269-4925-a2f6-6e9cecbb9128" Name="ConveyorReq" Comment="Adapter Interface" Namespace="Main">
  <Identification Standard="61499-1" />
  <VersionInfo Version="0.0" Author=" " Date="7/2/2026" />
  <InterfaceList>
    <EventInputs>
      <Event ID="F511818D72E4FD68" Name="DRV">
        <With Var="MotorOn" />
      </Event>
    </EventInputs>
    <EventOutputs>
      <Event ID="210167FBAD83B2B9" Name="REQ">
        <With Var="Request" />
      </Event>
    </EventOutputs>
    <InputVars>
      <VarDeclaration ID="B44949AC545C1846" Name="MotorOn" Type="BOOL" />
    </InputVars>
    <OutputVars>
      <VarDeclaration ID="8847AF2BD39930EF" Name="Request" Type="BOOL" />
    </OutputVars>
  </InterfaceList>
  <Service RightInterface="PLUG" LeftInterface="SOCKET">
    <ServiceSequence Name="request_confirm">
      <ServiceTransaction>
        <InputPrimitive Interface="SOCKET" Event="DRV" Parameters="MotorOn" />
        <OutputPrimitive Interface="PLUG" Event="DRV" Parameters="MotorOn" />
      </ServiceTransaction>
      <ServiceTransaction>
        <InputPrimitive Interface="PLUG" Event="CNF" Parameters="CNFD" />
        <OutputPrimitive Interface="SOCKET" Event="CNF" Parameters="CNFD" />
      </ServiceTransaction>
    </ServiceSequence>
    <ServiceSequence Name="indication_response">
      <ServiceTransaction>
        <InputPrimitive Interface="PLUG" Event="REQ" Parameters="Request" />
        <OutputPrimitive Interface="SOCKET" Event="REQ" Parameters="Request" />
      </ServiceTransaction>
      <ServiceTransaction>
        <InputPrimitive Interface="SOCKET" Event="RSP" Parameters="RSPD" />
        <OutputPrimitive Interface="PLUG" Event="RSP" Parameters="RSPD" />
      </ServiceTransaction>
    </ServiceSequence>
  </Service>
</AdapterType>