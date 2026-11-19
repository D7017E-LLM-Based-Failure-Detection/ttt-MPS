<?xml version="1.0" encoding="UTF-8"?>
  <!DOCTYPE AdapterType SYSTEM "../LibraryElement.dtd" >
  <AdapterType Name="IWorkpieceSupply" Namespace="Flexbridge.FestoMPS400" GUID="52fcf71c-35ce-495b-81b3-5cd02c7e7c7a"  Comment="Adapter Interface" >
    <Identification Standard="61499-1" />
    <VersionInfo Organization="Flexbridge AB" Version="0.0" Author="Sandeep Patil" Date="11/16/2026" />
  <CompilerInfo />
  <InterfaceList>
      <EventInputs>
        <Event ID="431829B32C6E3F75" Name="CNF" Comment="To the plug: the workpiece has been handed over" />
      </EventInputs>
      <EventOutputs>
        <Event ID="454823C778764207" Name="REQ" Comment="From the plug: please hand over one workpiece" />
      </EventOutputs>
    </InterfaceList>
    <Service RightInterface="PLUG" LeftInterface="SOCKET">
      <ServiceSequence Name="request_workpiece">
        <ServiceTransaction>
          <InputPrimitive Interface="PLUG" Event="REQ" />
          <OutputPrimitive Interface="SOCKET" Event="REQ" />
        </ServiceTransaction>
        <ServiceTransaction>
          <InputPrimitive Interface="SOCKET" Event="CNF" />
          <OutputPrimitive Interface="PLUG" Event="CNF" />
        </ServiceTransaction>
      </ServiceSequence>
    </Service>
  </AdapterType>
