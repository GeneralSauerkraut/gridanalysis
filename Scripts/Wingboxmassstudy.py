from math import exp
import numpy as np
import matplotlib.pyplot as plt

'''Absolute 0 is at the applied load'''
class Wingsection(object):
	"""docstring for Wingsection"""
	def __init__(self, length, ntop, nbot, offset):
		self.spacingupper = 0.400/(ntop + 1)
		self.spacinglower = 0.400/(nbot + 1)
		self.ab = length/self.spacingupper
		self.upper = ntop
		self.lower = nbot
		self.len = length
		self.offset = offset

		self.modulus = 72400*10**6
		self.skinthickness = 0.0008

		def getkc(ab):
			return 6.372*exp(-5.322*ab)+6.248*exp(0.002087*ab)

		self.kc = getkc(self.ab)

		"""For the Neutral axis and the Moment of Inertia Calculations the
		thin walled assumption is used and the lateral Stiffeners are ignored"""
		def getneutralaxis():
			astr = 40 * 1.5
			abox = 1200 * 0.8

			ytop = 150 - 5.375
			ybot = 5.375
			ybox = 75

			qtop = self.upper * astr * ytop
			qbot = self.lower * astr * ybot
			qbox = abox * ybox

			ages = self.upper * astr + self.lower * astr + abox
			qges = qtop + qbot + qbox
			return qges/ages
	
		def getinertia():
			astr = 40 * 1.5

			istr = 4022.5
			itop = 400 * 0.8 * (150 - self.axis) ** 2
			ibot = 400 * 0.8 * self.axis ** 2
			iside = 1 / 12 * 0.8 * (150 ** 3) + 150 * 0.8 * (75 - self.axis) ** 2

			ibox = itop + ibot + 2 * iside
			istrs = (self.upper + self.lower + 4) * istr

			stop = (self.upper + 2) * astr * (150 - self.axis) ** 2
			sbot = (self.lower + 2) * astr * self.axis ** 2

			i = ibox + istrs + stop + sbot
			i /= 10 ** 12
			return i

		self.axis = getneutralaxis()
		self.inertia = getinertia()
		self.axis /= 1000
		self.invertaxis = 0.15 - self.axis

		#now everything is in SI Units

		'''get the compressive Stress needed to cause buckling depending on the stringerspacing'''
		def getsigmabuckle():
			kc = self.kc
			e = self.modulus
			t = self.skinthickness
			b = self.spacingupper

			return kc*e*(t/b)**2

		self.sigmabuckle = getsigmabuckle()

class Wing(object):
	"""docstring for Wing"""
	def __init__(self, rib, nto, nbo):
		self.part0 = Wingsection(rib[0], nto[0], nbo[0], 0)
		self.part1 = Wingsection(rib[1]-rib[0], nto[1], nbo[1], rib[0])
		self.part2 = Wingsection(rib[2]-rib[1], nto[2], nbo[2], rib[1])

		
def Testcompression(specimen):
	data = np.zeros(1500)
	for i in range(0,1500):
		x=i/1000
		load = 2500
		Moment = x*load

		if x > specimen.part2.offset:
			data[i] = Moment*specimen.part2.invertaxis/specimen.part2.inertia
		elif x > specimen.part1.offset:
			data[i] = Moment*specimen.part1.invertaxis/specimen.part1.inertia
		else:
			data[i] = Moment*specimen.part0.invertaxis/specimen.part0.inertia

	return data/10**6

def Testbuckling(specimen):
	sigmamax = np.zeros(1500)
	for i in range(0,1500):
		x=i/1000

		if x > specimen.part2.offset:
			sigmamax[i] = specimen.part2.sigmabuckle
		elif x > specimen.part1.offset:
			sigmamax[i] = specimen.part1.sigmabuckle
		else:
			sigmamax[i] = specimen.part0.sigmabuckle

	return sigmamax/10**6

def Testtension(specimen):
	datas = np.zeros(1500)
	for i in range(0,1500):
		x=i/1000
		load = 2500
		Moment = x*load

		if x > specimen.part2.offset:
			if x < 1.2:
				datas[i] = Moment*specimen.part2.axis/specimen.part2.inertia
			else:
				datas[i] = Moment*specimen.part2.axis/specimen.part2.inertia*4/3
		elif x > specimen.part1.offset:
			datas[i] = Moment*specimen.part1.axis/specimen.part1.inertia
		else:
			datas[i] = Moment*specimen.part0.axis/specimen.part0.inertia

	return datas/10**6

def rivetspacing(data):
	spacing = np.zeros(1500)
	for i in range(0,1500):
		if data[i] != 0:
			spacing[i] = 0.0008*(0.9*2.1*72400/data[i])
		else:
			spacing[i] = None
	return spacing

ribs=np.array([0.23, 1.17, 1.5])
upper=np.array([0,3,5])
lower = np.array([0,2,5])

box = Wing(ribs,upper,lower)
sig = Testcompression(box)
lim = Testbuckling(box)

plt.plot(sig)
plt.plot(lim)
plt.show()
