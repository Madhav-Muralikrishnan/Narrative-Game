using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class TimelineEnding : MonoBehaviour
{
    public PlayableDirector playableDirector; // Add reference to attached PlayableDirector component from Inspector
	private TimelineAsset someTimelineAsset; 

    private int counter = 0;

	// Use this for initialization
	void Start () {

		someTimelineAsset = (TimelineAsset)playableDirector.playableAsset;

		if(QuestController.staticIsBrown == true)
		{
			counter++;
		}

		if(QuestController.staticIsGreen == true)
		{
			counter++;
		}

		if(QuestController.staticIsBlue == true)
		{
			counter++;
		}

		ClearMutes(35);
		counter = 0;

		if(counter == 0)
		{
			MuteUnmuteTrack(1);
			MuteUnmuteTrack(2);
			MuteUnmuteTrack(3);
			MuteUnmuteTrack(4);
			MuteUnmuteTrack(5);
			MuteUnmuteTrack(6);
			MuteUnmuteTrack(7);
			MuteUnmuteTrack(8);
			MuteUnmuteTrack(9);
			MuteUnmuteTrack(10);
			MuteUnmuteTrack(11);
			MuteUnmuteTrack(12);
			MuteUnmuteTrack(13);
			MuteUnmuteTrack(14);
			MuteUnmuteTrack(15);
			MuteUnmuteTrack(16);
			MuteUnmuteTrack(17);
			MuteUnmuteTrack(18);
			MuteUnmuteTrack(19);
			MuteUnmuteTrack(20);
			MuteUnmuteTrack(21);
			MuteUnmuteTrack(22);
			MuteUnmuteTrack(23);
			MuteUnmuteTrack(24);
			MuteUnmuteTrack(26);
			MuteUnmuteTrack(27);
			MuteUnmuteTrack(28);
			MuteUnmuteTrack(29);
			MuteUnmuteTrack(30);
			MuteUnmuteTrack(31);
			MuteUnmuteTrack(35);
		}

		if(counter == 1)
		{
			MuteUnmuteTrack(1);
			MuteUnmuteTrack(2);
			MuteUnmuteTrack(3);
			MuteUnmuteTrack(4);
			MuteUnmuteTrack(5);
			MuteUnmuteTrack(11);
			MuteUnmuteTrack(12);
			MuteUnmuteTrack(13);
			MuteUnmuteTrack(14);
			MuteUnmuteTrack(15);
			MuteUnmuteTrack(16);
			MuteUnmuteTrack(17);
			MuteUnmuteTrack(18);
			MuteUnmuteTrack(19);
			MuteUnmuteTrack(20);
			MuteUnmuteTrack(21);
			MuteUnmuteTrack(22);
			MuteUnmuteTrack(23);
			MuteUnmuteTrack(24);
			MuteUnmuteTrack(26);
			MuteUnmuteTrack(27);
			MuteUnmuteTrack(28);
			MuteUnmuteTrack(29);
			MuteUnmuteTrack(30);
			MuteUnmuteTrack(31);
			MuteUnmuteTrack(35);
		}

		if(counter == 2)
		{
			MuteUnmuteTrack(6);
			MuteUnmuteTrack(7);
			MuteUnmuteTrack(8);
			MuteUnmuteTrack(9);
			MuteUnmuteTrack(10);
			MuteUnmuteTrack(16);
			MuteUnmuteTrack(17);
			MuteUnmuteTrack(18);
			MuteUnmuteTrack(19);
			MuteUnmuteTrack(20);
			MuteUnmuteTrack(21);
			MuteUnmuteTrack(22);
			MuteUnmuteTrack(23);
			MuteUnmuteTrack(25);
			MuteUnmuteTrack(26);
			MuteUnmuteTrack(27);
			MuteUnmuteTrack(28);
			MuteUnmuteTrack(32);
			MuteUnmuteTrack(33);
			MuteUnmuteTrack(34);
			MuteUnmuteTrack(35);
		}

		if(counter == 3)
		{
			MuteUnmuteTrack(6);
			MuteUnmuteTrack(7);
			MuteUnmuteTrack(8);
			MuteUnmuteTrack(9);
			MuteUnmuteTrack(10);
			MuteUnmuteTrack(24);
			MuteUnmuteTrack(25);
			MuteUnmuteTrack(29);
			MuteUnmuteTrack(30);
			MuteUnmuteTrack(31);
			MuteUnmuteTrack(32);
			MuteUnmuteTrack(33);
			MuteUnmuteTrack(34);

			
		}
		

	}
	
	// Update is called once per frame
	void Update () {
		print(counter + " :counter");
	}

	void MuteUnmuteTrack(int trackIndex)
	{
		
		TrackAsset someTimelineTrackAsset = someTimelineAsset.GetOutputTrack(trackIndex);
		
		someTimelineTrackAsset.muted = true;

		double t = playableDirector.time; // Store elapsed time
		playableDirector.RebuildGraph(); // Rebuild graph
		playableDirector.time = t; // Restore elapsed time
	}

	void ClearMutes(int trackLength)
	{
		for(int i = 0; i < trackLength; i++)
		{
			TrackAsset someTimelineTrackAsset = someTimelineAsset.GetOutputTrack(i);
			someTimelineTrackAsset.muted = false;
		}
	}
}
