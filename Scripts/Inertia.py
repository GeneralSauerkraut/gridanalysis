import numpy as np

def getneutralaxis(upper, lower):
	astr = 40 * 1.5
	abox = 1200 * 0.8

	ytop = 150 - 5.375
	ybot = 5.375
	ybox = 75

	qtop =  upper * astr * ytop
	qbot =  lower * astr * ybot
	qbox = abox * ybox

	ages =  upper * astr +  lower * astr + abox
	qges = qtop + qbot + qbox
	return qges/ages
	
def getinertia(upper, lower, axis):
	astr = 40 * 1.5

	istr = 4022.5
	itop = 400 * 0.8 * (150 -  axis) ** 2
	ibot = 400 * 0.8 *  axis ** 2
	iside = 1 / 12 * 0.8 * (150 ** 3) + 150 * 0.8 * (75 -  axis) ** 2

	ibox = itop + ibot + 2 * iside
	istrs = ( upper +  lower + 4) * istr

	stop = ( upper + 2) * astr * (150 -  axis) ** 2
	sbot = ( lower + 2) * astr *  axis ** 2

	i = ibox + istrs + stop + sbot
	i /= 10 ** 12
	return i

size = 15

axis = np.zeros((size,size))
invaxis = np.zeros((size,size))
inertia = np.zeros((size,size))
spacing = np.zeros((size,size))

for i in range(0,size):
	for j in range(0,size):
		axis[i, j] = getneutralaxis(i,j)/1000
		inertia[i, j] = getinertia(i,j,getneutralaxis(i,j))
		invaxis[i, j] = 0.15-axis[i, j]
		spacing[i, j] = 0.4/(i+1)

np.savetxt('axis.csv', axis, delimiter=';')
np.savetxt('inertia.csv', inertia, delimiter=';')
np.savetxt('invaxis.csv', invaxis, delimiter=';')
np.savetxt('spacing.csv', spacing, delimiter=';')
