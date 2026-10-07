<?xml version="1.0" encoding="utf-8"?>
<!DOCTYPE AdapterType SYSTEM "../LibraryElement.dtd">
<AdapterType GUID="bc1bc282-0d14-483b-81c9-de5d3bea812a" Name="CONVEYOR_HS" Comment="Adapter Interface" Namespace="Main">
  <Identification Standard="61499-1" />
  <VersionInfo Version="0.0" Author=" " Date="7/2/2026" />
  <InterfaceList>
    <EventInputs>
      <Event ID="B4B09F4C73496EAE" Name="RSP" Comment="Response from Socket">
        <With Var="Workpiece" />
        <With Var="Tray" />
      </Event>
    </EventInputs>
    <EventOutputs>
      <Event ID="940328B7C92671F4" Name="REQ" Comment="Confirmation from Plug" />
      <Event ID="B4C20C06D382BE8A" Name="READY" Comment="Indication from Plug" />
    </EventOutputs>
    <InputVars>
      <VarDeclaration ID="3526B3C3390397AC" Name="Tray" Type="BOOL" Comment="Request Data from Socket" />
      <VarDeclaration ID="9965CC9B778B20E2" Name="Workpiece" Type="BOOL" Comment="Response Data from Socket" />
    </InputVars>
  </InterfaceList>
  <Service RightInterface="PLUG" LeftInterface="SOCKET">
    <ServiceSequence Name="request_confirm">
      <ServiceTransaction>
        <InputPrimitive Interface="SOCKET" Event="REQ" Parameters="Tray" />
        <OutputPrimitive Interface="PLUG" Event="REQ" Parameters="Tray" />
      </ServiceTransaction>
      <ServiceTransaction>
        <InputPrimitive Interface="PLUG" Event="REQ" Parameters="CNFD" />
        <OutputPrimitive Interface="SOCKET" Event="REQ" Parameters="CNFD" />
      </ServiceTransaction>
    </ServiceSequence>
    <ServiceSequence Name="indication_response">
      <ServiceTransaction>
        <InputPrimitive Interface="PLUG" Event="READY" Parameters="INDD" />
        <OutputPrimitive Interface="SOCKET" Event="READY" Parameters="INDD" />
      </ServiceTransaction>
      <ServiceTransaction>
        <InputPrimitive Interface="SOCKET" Event="RSP" Parameters="Workpiece" />
        <OutputPrimitive Interface="PLUG" Event="RSP" Parameters="Workpiece" />
      </ServiceTransaction>
    </ServiceSequence>
  </Service>
</AdapterType>