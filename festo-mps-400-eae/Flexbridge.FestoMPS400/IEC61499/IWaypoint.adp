<?xml version="1.0" encoding="UTF-8"?>
  <!DOCTYPE AdapterType SYSTEM "../LibraryElement.dtd" >
  <AdapterType Name="IWaypoint" Namespace="Flexbridge.FestoMPS400" GUID="dc2db48e-d27c-45e6-ad86-ce0ed20002e2"  Comment="Adapter Interface" >
    <Identification Standard="61499-1" />
    <VersionInfo Organization="Flexbridge AB" Version="0.0" Author="Sandeep Patil" Date="11/16/2026" />
  <CompilerInfo />
  <InterfaceList>
      <EventInputs>
        <Event ID="CC69AC5927E3BA0A" Name="TRAY" Comment="To the plug: tray state changed (or answer to STATE_REQ)">
          <With Var="Tray" />
          <With Var="Workpiece" />
        </Event>
      </EventInputs>
      <EventOutputs>
        <Event ID="23841455BFB75E8E" Name="STATE_REQ" Comment="From the plug: tell me the tray state" />
        <Event ID="7B4C38636560D234" Name="RELEASE" Comment="From the plug: release the tray" />
      </EventOutputs>
      <InputVars>
        <VarDeclaration ID="AA0A6136C0254B64" Name="Tray" Type="BOOL" Comment="A tray is at the stopper" />
        <VarDeclaration ID="052E53D7D6EE241D" Name="Workpiece" Type="BOOL" Comment="The tray carries a workpiece" />
      </InputVars>
    </InterfaceList>
    <Service RightInterface="PLUG" LeftInterface="SOCKET">
      <ServiceSequence Name="tray">
        <ServiceTransaction>
          <InputPrimitive Interface="PLUG" Event="STATE_REQ" />
          <OutputPrimitive Interface="SOCKET" Event="STATE_REQ" />
        </ServiceTransaction>
        <ServiceTransaction>
          <InputPrimitive Interface="SOCKET" Event="TRAY" Parameters="Tray, Workpiece" />
          <OutputPrimitive Interface="PLUG" Event="TRAY" Parameters="Tray, Workpiece" />
        </ServiceTransaction>
        <ServiceTransaction>
          <InputPrimitive Interface="PLUG" Event="RELEASE" />
          <OutputPrimitive Interface="SOCKET" Event="RELEASE" />
        </ServiceTransaction>
      </ServiceSequence>
    </Service>
  </AdapterType>
